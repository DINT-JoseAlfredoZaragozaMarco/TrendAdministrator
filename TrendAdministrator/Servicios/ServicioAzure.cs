﻿using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendAdministrator.Servicios
{
    class ServicioAzure
    {
        private readonly string claveConexion = Properties.Settings.Default.ClaveAzure;
        
        /// <summary>
        ///     Nombre del contenedor de las imágenes en Azure.
        /// </summary>
        private readonly string nombreContenedorImagenesAzure = Properties.Settings.Default.NombreContenedorImagenesAzure;
        
        /// <summary>
        ///     Método para almacenar una imagen en el BlobStorage de Azure.
        /// </summary>
        /// <param name="rutaImagen">string que contiene la ruta de la imagen en el sistema.</param>
        /// <returns>Ruta que Azure le ha asignado a la imagen.</returns>
        public string AlmacenarImagenEnLaNube(string rutaImagen)
        {
            if (rutaImagen != "")
            {
                var clienteBlobService = new BlobServiceClient(claveConexion);
                var clienteContenedor = clienteBlobService.GetBlobContainerClient(nombreContenedorImagenesAzure);

                Stream streamImagen = File.OpenRead(rutaImagen);
                string nombreImagen = Path.GetFileName(rutaImagen);

                if (!clienteContenedor.GetBlobClient(nombreImagen).Exists())
                    clienteContenedor.UploadBlob(nombreImagen, streamImagen);

                var clienteBlobImagen = clienteContenedor.GetBlobClient(nombreImagen);

                return clienteBlobImagen.Uri.AbsoluteUri;
            }
            else return "";
        }
    }
}

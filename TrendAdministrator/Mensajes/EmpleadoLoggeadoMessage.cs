﻿using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrendAdministrator.Modelos;

namespace TrendAdministrator.Mensajes
{
    class EmpleadoLoggeadoMessage : ValueChangedMessage<Employees>
    {
        public EmpleadoLoggeadoMessage(Employees value) : base(value) { }
    }
}

﻿using DTOs.DTOs.Envio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.ICasosUso.ICUEnvio
{
    public interface ICUGetEnvioTracking
    {
        public DTOEnvio Ejecutar(string nroTracking);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FFY.Web.Mappings
{
    public interface IMapperProvider
    {
        TDestination Map<TDestination>(object source);
    }
}
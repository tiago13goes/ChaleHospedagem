﻿using ChaleHospedagem.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChaleHospedagem.Domain.Interface.Repositories
{
    public interface IRepositoryChale_Item : IRepositoryBase<Chale_Item>
    {
        bool Remove(Chale_Item cod);
    }
}

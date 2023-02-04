﻿using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public class LoaiRepositoryInMemory : ILoaiRepository
    {
        static List<LoaiVM> loais = new List<LoaiVM> {
            new LoaiVM { MaLoai = 1, TenLoai ="Tivi"},
             new LoaiVM { MaLoai = 2, TenLoai = "Tủ lạnh" },
              new LoaiVM { MaLoai = 3, TenLoai = "Máy giặt" },
               new LoaiVM { MaLoai = 4, TenLoai = "Điều hòa" },
                new LoaiVM { MaLoai = 5, TenLoai = "Nồi chiên không giàu" }
            };
        public LoaiVM Add(LoaiModel loai)
        {
            var _loai = new LoaiVM
            {
                MaLoai = loais.Max(lo => lo.MaLoai) + 1,
                TenLoai = loai.TenLoai
            };
            loais.Add(_loai);
            return _loai;
           
            
        }

        public void Delete(int id)
        {
            var _loai = loais.SingleOrDefault(lo => lo.MaLoai == id);
            loais.Remove(_loai);

        }

        public List<LoaiVM> GetAll()
        {
           return loais;
        }

        public LoaiVM GetById(int id)
        {
            return loais.SingleOrDefault(lo => lo.MaLoai == id); 
        }

        public void Update(LoaiVM loai)
        {
            var _loai = loais.SingleOrDefault(lo => lo.MaLoai == loai.MaLoai);
            if(_loai !=null)
            {
                _loai.TenLoai = loai.TenLoai;
            }
        }
    }
}

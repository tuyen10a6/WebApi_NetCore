using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Implementation;
using MyWebApiApp.Data;
using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public class HangHoaRepository : IHangHoaResposity
    {
        private readonly MyDBContext _context;
        public static int PAGE_SIZE { get; set; } = 5;
        public HangHoaRepository(MyDBContext context)
        {
            _context = context;
        }
        public List<HangHoaVM> GetAll()
        {
            var HH = _context.HangHoas.Select(lo => new HangHoaVM
            {
                MaHangHoa = lo.MaHH,
                TenHH = lo.TenHH,
                MoTa = lo.MoTa,
                DonGia = lo.DonGia,
                GiamGia = lo.GiamGia,
                MaLoai = lo.MaLoai,

            });
            return HH.ToList();

        }
        public List<HangHoaModel> GetAll(string? search, double? from, double? to, string? SortBy, int page = 1)
        {
            var allProducts = _context.HangHoas.Include(hh => hh.Loai).AsQueryable();
            #region filtering
            if (!string.IsNullOrEmpty(search))
            {
                allProducts = allProducts.Where(hh => hh.TenHH.Contains(search));

            }
            if (from.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.DonGia >= from);
            }
            if (to.HasValue)
            {
                allProducts = allProducts.Where(hh => hh.DonGia <= to);
            }
            #endregion
            #region Sorting
            //Defaul sory by Name(TenHH)
            allProducts = allProducts.OrderBy(hh => hh.TenHH);
            if (!string.IsNullOrEmpty(SortBy))
            {
                switch (SortBy)
                {
                    case "tenhh_desc":
                        allProducts = allProducts.OrderByDescending(hh => hh.TenHH);
                        break;

                    case "gia_asc":
                        allProducts = allProducts.OrderBy(hh => hh.DonGia);
                        break;
                    case "gia_desc":
                        allProducts = allProducts.OrderByDescending(hh => hh.DonGia);
                        break;

                }
            }
            #endregion
            //#region Paging
            //allProducts = allProducts.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            //#endregion
            //var result = allProducts.Select(hh => new HangHoaModel
            //{
            //    MaHH = hh.MaHH,
            //    TenHH = hh.TenHH,
            //    DonGia = hh.DonGia,
            //    TenLoai = hh.TenHH
            //});
            //return result.ToList();
            var result = PaginatedList<HangHoa>.Create(allProducts, page, PAGE_SIZE);
            return result.Select(hh => new HangHoaModel
            {
                MaHangHoa = hh.MaHH,
                TenHH = hh.TenHH,
                DonGia = hh.DonGia,
                MaLoai = hh.MaLoai,
                TenLoai = hh.Loai?.TenLoai
            }).ToList();

        }
     
        List<HangHoaVM> IHangHoaResposity.GetAll()
        {
            throw new NotImplementedException();
        }

        public HangHoaVM Add(HangHoas hh)
        {
            var _HangHoa = new HangHoa
            {
                TenHH = hh.TenHH,
                MoTa = hh.MoTa,
                DonGia = hh.DonGia,
                GiamGia = hh.GiamGia,
                MaLoai = hh.MaLoai

            };
            _context.Add(_HangHoa);
            _context.SaveChanges();
            return new HangHoaVM
            {
                MaHangHoa = _HangHoa.MaHH,
                TenHH = _HangHoa.TenHH,
                MoTa = _HangHoa.MoTa,
                DonGia = _HangHoa.DonGia,
                GiamGia = _HangHoa.GiamGia,
                MaLoai = _HangHoa.MaLoai
            };
        }

        public void Update(HangHoaVM loai)
        {
            throw new NotImplementedException();
        }

        public LoaiVM GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        HangHoaVM IHangHoaResposity.GetById(int id)
        {
            throw new NotImplementedException();
        }

       
    }
}

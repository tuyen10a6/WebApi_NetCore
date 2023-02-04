using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public interface IHangHoaResposity
    {
        List<HangHoaModel> GetAll(string? search, double? from ,double? to, string? SortBy, int page = 1);
        List<HangHoaVM> GetAll();
        LoaiVM GetById(int id);
        LoaiVM Add(HangHoaModel loai);
        void Update(HangHoaVM loai);
        void Delete(int id);


    }
}

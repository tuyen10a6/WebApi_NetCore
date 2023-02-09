using MyWebApiApp.Models;

namespace MyWebApiApp.Services
{
    public interface IHangHoaResposity
    {
        List<HangHoaModel> GetAll(string? search, double? from ,double? to, string? SortBy, int page = 1);
        List<HangHoaVM> GetAll();
        HangHoaVM GetById(int id);
       HangHoaVM Add(HangHoas loai);
        void Update(HangHoaVM loai);
        void Delete(int id);


    }
}

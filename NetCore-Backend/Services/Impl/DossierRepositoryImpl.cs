using NetCore_Backend.Data;
using NetCore_Backend.Models;

namespace NetCore_Backend.Services.Impl
{
    public class DossierRepositoryImpl : IDossierRepository
    {
        private readonly MyDbContext _context;
        public DossierRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }

        public List<DossierModel> GetAll()
        {
            var dossiers = _context.Dossiers.Where(d => d.IsActive == 0).Select(d => new DossierModel()
            {
                Id = d.Id,
                GalaryId = (long)d.GalaryId,
                AspNetUsersId = d.AspNetUsersId,
                NumberId = d.NumberId,
                IsActive = d.IsActive,
                Created = d.Created,
                Updated = d.Updated,
            });
            return dossiers.ToList();
        }

        public DossierModel GetById(long id)
        {
            var d = _context.Dossiers.FirstOrDefault(d => d.Id == id);
            if (d != null)
            {
                return new DossierModel()
                {
                    Id = d.Id,
                    GalaryId = (long)d.GalaryId,
                    AspNetUsersId = d.AspNetUsersId,
                    NumberId = d.NumberId,
                    IsActive = d.IsActive,
                    Created = d.Created,
                    Updated = d.Updated,
                };
            }

            return null;
        }

        public DossierModel Add(DossierModel dossierModel)
        {
            var _dossier = new Dossier();
           
            _dossier.GalaryId = dossierModel.GalaryId;
            _dossier.AspNetUsersId = dossierModel.AspNetUsersId;
            _dossier.NumberId = dossierModel.NumberId;
            _dossier.IsActive = dossierModel.IsActive;
            _dossier.Created = dossierModel.Created;
            _dossier.Updated = dossierModel.Updated;
            _context.Dossiers.Add(_dossier);
            _context.SaveChanges();
            return new DossierModel()
            {
               
                GalaryId = (long)_dossier.GalaryId,
                AspNetUsersId = _dossier.AspNetUsersId,
                NumberId = _dossier.NumberId,
                IsActive = _dossier.IsActive,
                Created = _dossier.Created,
                Updated = _dossier.Updated,
            };
        }

        public void Update(DossierModel dossierModel)
        {
            var _dossier = _context.Dossiers.FirstOrDefault(d => d.Id == dossierModel.Id);
            if (_dossier != null)
            {
                _dossier.GalaryId = dossierModel.GalaryId;
                _dossier.AspNetUsersId = _dossier.AspNetUsersId;
                _dossier.NumberId = _dossier.NumberId;
                _dossier.IsActive = _dossier.IsActive;
                _dossier.Updated = _dossier.Updated;
                _context.Update(_dossier);
                _context.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            var dossier = _context.Dossiers.FirstOrDefault(d => d.Id == id);
            if (dossier != null)
            {
                dossier.IsActive = 1;
                _context.SaveChanges();
            }
        }
    }
}

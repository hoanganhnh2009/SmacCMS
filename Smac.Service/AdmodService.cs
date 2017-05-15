using Smac.Data.Infrastructure;
using Smac.Data.Repositories;
using Smac.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tedu.Common.Result;

namespace Smac.Service
{
    public class AdModService
    {
        private AdModRepository _admodRepository;
        private IUnitOfWork _unitOfWork;

        public AdModService(AdModRepository repository, IUnitOfWork unitOfWork)
        {
            this._admodRepository = repository;
            this._unitOfWork = unitOfWork;
        }

        public Result<List<AdMod>> GetAdmodByUser(ApplicationUser user)
        {
            try
            {
                var lstAdmod=this._admodRepository.Search(o => o.Users.Contains(user)).ToList();
                if (lstAdmod != null && lstAdmod.Count() > 0)
                {
                    return new Result<List<AdMod>>(ResultCode.SUCCESS, string.Format(ResultMessage.SUCCESS, lstAdmod.Count(), "Admin Mod"), lstAdmod);
                }
                else
                {
                    return new Result<List<AdMod>>(ResultCode.NOT_FOUND, string.Format(ResultMessage.NOT_FOUND, "Admin Mod"), new List<AdMod>());
                }

            }
            catch (Exception ex)
            {
                return new Result<List<AdMod>>(ResultCode.FAIL, ResultMessage.UNKNOWN + ":" + ex.Message, null);
            }
        }
    }
}
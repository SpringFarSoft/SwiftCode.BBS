using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftCode.BBS.IRepositories.BASE;
using SwiftCode.BBS.IServices.BASE;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Services.BASE;

namespace SwiftCode.BBS.IRepositories
{
    public class AdvertisementService : BaseServices<Advertisement>, IAdvertisementService
    {
        public AdvertisementService(IBaseRepository<Advertisement> baseDal) : base(baseDal)
        {
        }
    }
}

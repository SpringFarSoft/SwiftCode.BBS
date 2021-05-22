using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SwiftCode.BBS.EntityFramework;
using SwiftCode.BBS.IRepositories.BASE;
using SwiftCode.BBS.Model.Models;
using SwiftCode.BBS.Repositories.BASE;

namespace SwiftCode.BBS.IRepositories
{
    public class AdvertisementRepository : BaseRepository<Advertisement>
    {
        public AdvertisementRepository(SwiftCodeBbsContext context) : base(context)
        {
        }
    }
}

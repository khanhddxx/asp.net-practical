
namespace eLink.BookingVcmReport.Endpoints
{
    using Serenity.Data;
    using Serenity.Services;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web.Mvc;
    using MyRepository = Repositories.CssVcmBaoCaoNCCRepository;
    using MyRow = Entities.CssVcmBaoCaoNCCRow;

    [RoutePrefix("Services/BookingVcmReport/CssVcmBaoCaoNCC"), Route("{action}")]
    [ConnectionKey("Default")]
    public class CssVcmBaoCaoNCCController : ServiceEndpoint
    {
        [HttpPost]
        public SaveResponse Create(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository().Create(uow, request);
        }

        [HttpPost]
        public SaveResponse Update(IUnitOfWork uow, SaveRequest<MyRow> request)
        {
            return new MyRepository().Update(uow, request);
        }

        [HttpPost]
        public DeleteResponse Delete(IUnitOfWork uow, DeleteRequest request)
        {
            return new MyRepository().Delete(uow, request);
        }

        public RetrieveResponse<MyRow> Retrieve(IDbConnection connection, RetrieveRequest request)
        {
            return new MyRepository().Retrieve(connection, request);
        }


        public ListResponse<MyRow> List(IDbConnection connection, ListRequest request)
        {
            ListResponse<MyRow> rs = new MyRepository().List(connection, request);
            rs.Entities = new List<MyRow>();
            rs.Entities.AddRange(connection.Query<MyRow>("" +
                @"SELECT DISTINCT Id,
                            Vendor,
                            Vendor_SupplyingSite
                    FROM    dbo.CSS_VCM_DANH_SACH_PO WITH(NOLOCK)
                    WHERE   CONCAT('NCC', Vendor) NOT IN(SELECT   Username
                                                         FROM     dbo.Users WITH(NOLOCK)); ").ToList());
            return rs;
        }
    }
}

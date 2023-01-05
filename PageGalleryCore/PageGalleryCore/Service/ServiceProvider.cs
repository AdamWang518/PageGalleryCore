using PageGalleryCore.Models;
using PageGalleryCore.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace PageGalleryCore.Service
{
    public class ServiceProvider
    {
        public ServiceProvider()
        {
        }
        public Response selectResult(string artist, string name, string attribute, string year, int page)
        {
            String sqlcmd = "";
            if (year == null)
            {
                sqlcmd = $"SELECT * FROM gallery_table WHERE artist LIKE '%{artist}%' AND drawName LIKE '%{name}%' AND attribute LIKE '%{attribute}%' Order By id  Offset {page - 1}*20 Rows Fetch Next 20 Rows Only";
            }
            else
            {
                int centuryStart = int.Parse(year) - 1;
                sqlcmd = $"SELECT * FROM gallery_table WHERE artist LIKE '%{artist}%' AND drawName LIKE '%{name}%' AND attribute LIKE '%{attribute}%' AND startYear BETWEEN {centuryStart * 100} AND {centuryStart * 100 + 99} Order By id  Offset {page - 1}*20 Rows Fetch Next 20 Rows Only";
            }
            Database database = new Database(sqlcmd);
            List<draw> drawList = new List<draw>();
            SqlDataReader dr = database.selector();
            while (dr.Read())
            {
                draw model = new draw();
                model.id = (Guid)dr["id"];
                model.artist = (String)dr["artist"];
                model.startYear = (String)dr["startYear"];
                model.endYear = (String)dr["endYear"];
                model.drawName = (String)dr["drawName"];
                model.attribute = (String)dr["attribute"];
                model.imageLink = (String)dr["imageLink"];
                drawList.Add(model);
            }
            dr.Close();
            if (year == null)
            {
                sqlcmd = $"SELECT COUNT(*) AS counts FROM gallery_table WHERE artist LIKE '%{artist}%' AND drawName LIKE '%{name}%' AND attribute LIKE '%{attribute}%'";
            }
            else
            {
                int centuryStart = int.Parse(year) - 1;
                sqlcmd = $"SELECT COUNT(*) AS counts FROM gallery_table WHERE artist LIKE '%{artist}%' AND drawName LIKE '%{name}%' AND attribute LIKE '%{attribute}%' AND startYear BETWEEN {centuryStart * 100} AND {centuryStart * 100 + 99}";
            }
            int count = 0;
            database = new Database(sqlcmd);
            dr = database.selector();
            while (dr.Read())
            {
                count = (int)dr["counts"];
            }
            dr.Close();
            database.sqlConnection.Close();
            Response response = new Response(drawList, count);
            return response;
        }
    }
}

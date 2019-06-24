using System.Data;

namespace Automation.Grouping
{
    public interface IBaseGroup
    {
        DataTable GetAllDetailsGroupInfo();

        DataTable GetCountGroupInfo();
    }
}
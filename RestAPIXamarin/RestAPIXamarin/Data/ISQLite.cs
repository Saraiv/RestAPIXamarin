using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestAPIXamarin.Data
{
    public interface ISQLite{
        SQLiteConnection GetConnection();
    }
}

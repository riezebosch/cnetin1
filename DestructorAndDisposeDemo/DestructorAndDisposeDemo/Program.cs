using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestructorAndDisposeDemo
{
    class Program
    {
        class DoetIetsMetEenExternalResource : IDisposable
        {
            private int _externeResource;
            private bool _isDisposed;

            public DoetIetsMetEenExternalResource()
            {
                Console.WriteLine("Constructor");
                _externeResource = 5;
            }

            ~DoetIetsMetEenExternalResource()
            {
                Console.WriteLine("Destructor");
                Dispose(false);
            }

            public void Dispose()
            {
                Console.WriteLine("Dispose");
                Dispose(true);
            }

            protected virtual void Dispose(bool isDisposing)
            {
                if (!_isDisposed)
                {
                    // Geen base dus check op isDisposing niet nodig.
                    _externeResource = 0;
                    _isDisposed = true;
                }
            }
        }

        class AfgeleideVanIetsMetResource : DoetIetsMetEenExternalResource
        {
            private int _eeneigenresource;
            private bool _isDisposed;

            public AfgeleideVanIetsMetResource()
            {
                _eeneigenresource = 3;
            }

            ~AfgeleideVanIetsMetResource()
            {
                this.Dispose(false);
            }

            public override void Dispose(bool isDisposing)
            {
                // Alleen disposes als dat niet al eerder is gedaan.
                if (_isDisposed)
                {
                    // Vanuit Dispose aangeroepen en dus niet vanuit de finalizer
                    // omdat in dat geval de finalizer van de base al automatisch
                    // aangeroepen wordt.
                    if (isDisposing)
                    {
                        base.Dispose(isDisposing);
                    }

                    _isDisposed = true;
                    _eeneigenresource = 0;
                }
            }
        }

        static void Main(string[] args)
        {
            var res = new DoetIetsMetEenExternalResource();
            res.Dispose();

            // Met nette exception handling
            var afgeleide = new AfgeleideVanIetsMetResource();
            try
            {
                throw new ArgumentNullException();
            }
            finally
            {
                afgeleide.Dispose();
            }

            // Dit is precies hetzelfde als bovenstaande
            using (var afgeleide2 = new AfgeleideVanIetsMetResource())
            {
            }


            // kan niet, want int is geen IDisposable
            //using (int i = 4)
            //{
            //}

            using (SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=masterdb;Integrated Security=SSPI"))
            using (SqlCommand comm = new SqlCommand("SELECT * FROM dbo.Databases", con))
            {
                con.Open();
                comm.ExecuteNonQuery();
            }
        }
    }
}

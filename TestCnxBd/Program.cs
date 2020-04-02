using MySql.Data.MySqlClient;

using System.Collections.Generic;
using System.Data;

namespace TestCnxBd
{
    class Program
    {
        static void Main(string[] args)
        {
            GetListProduit();
        }
        public static List<Produit> GetListProduit()
        {
            List<Produit> result = new List<Produit>();
            Produit produit; 
            MySqlConnection cnx = new MySqlConnection();
            cnx.ConnectionString = "Server = 127.0.0.1; Uid = root; password = root; Database = mysql; ";
            cnx.Open();

            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Produits";
            cmd.CommandType = CommandType.TableDirect;
            cmd.Connection = cnx;

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                produit = new Produit();
                produit.Id = int.Parse(dr["IdProd"].ToString());
                produit.Nom = dr["NomProd"].ToString();
                produit.Qty = int.Parse(dr["QtyProd"].ToString());
                produit.Prix = double.Parse(dr["PrixProd"].ToString());

                result.Add(produit);
            }

            cnx.Close();
            //Console.WriteLine(result);
            return result;
        }
    }

}   


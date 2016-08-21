using System;
using System.Collections.ObjectModel;
using SQLite.Net;

namespace AluraNutricao.Data
{
    public class RefeicaoDAO
    {
        public SQLiteConnection Conexao { get; set; }
        private ObservableCollection<Refeicao> lista;

        public ObservableCollection<Refeicao> Lista
        {
            get
            {
                if(lista == null)
                    lista = GetAll();

                return lista;
            }
            set
            {
                lista = value;
            }
        }

        public RefeicaoDAO(SQLiteConnection conn)
        {
            Conexao = conn;
            Conexao.CreateTable<Refeicao>();
        }

        public void Salvar(Refeicao refeicao)
        {
            Conexao.Insert(refeicao);
            lista.Add(refeicao);
        }

        private ObservableCollection<Refeicao> GetAll()
        {
            return new ObservableCollection<Refeicao>(Conexao.Table<Refeicao>());
        }

        public void Remove(Refeicao refeicao)
        {
            Conexao.Delete<Refeicao>(refeicao.Id);
            lista.Remove(refeicao);
        }
    }
}

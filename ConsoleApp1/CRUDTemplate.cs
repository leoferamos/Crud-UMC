using System;

namespace ConsoleCRUD
{
    public abstract class CRUDTemplate<T>
    {
        public void ExecuteCRUDOperation(T entity)
        {
            if (Connect())
            {
                PrepareData(entity);
                ExecuteOperation(entity);
                HandleResult();
                Disconnect();
            }
            else
            {
                Console.WriteLine("Não foi possível estabelecer conexão com o banco de dados.");
            }
        }

        
        public abstract bool Connect();
        protected abstract void PrepareData(T entity);        
        protected abstract void ExecuteOperation(T entity);        
        protected abstract void HandleResult();        
        protected abstract void Disconnect();
    }

    public class AlunoCreateOperation : CRUDTemplate<Aluno>
    {
        public override bool Connect()
        {
            Console.WriteLine("Conectado ao banco de dados.");
            return true;
        }

        protected override void PrepareData(Aluno entity)
        {
            Console.WriteLine("Preparando dados do aluno para inserção...");
        }

        protected override void ExecuteOperation(Aluno entity)
        {
                        Console.WriteLine("Inserindo aluno no banco de dados...");
        }

        protected override void HandleResult()
        {
            Console.WriteLine("Aluno inserido com sucesso.");
        }

        protected override void Disconnect()
        {            
            Console.WriteLine("Desconectando do banco de dados.");
        }
    }

    public class AlunoReadOperation : CRUDTemplate<Aluno>
    {
        public override bool Connect()
        {            
            Console.WriteLine("Conectado ao banco de dados.");
            return true;
        }

        protected override void PrepareData(Aluno entity)
        {
        }

        protected override void ExecuteOperation(Aluno entity)
        {
            
            Console.WriteLine("Buscando aluno no banco de dados...");
        }

        protected override void HandleResult()
        {
            
            Console.WriteLine("Aluno encontrado.");
        }

        protected override void Disconnect()
        {
           
            Console.WriteLine("Desconectando do banco de dados.");
        }
    }

    public class AlunoUpdateOperation : CRUDTemplate<Aluno>
    {
        public override bool Connect()
        {            
            Console.WriteLine("Conectado ao banco de dados.");
            return true;
        }

        protected override void PrepareData(Aluno entity)
        {
            Console.WriteLine("Preparando dados do aluno para atualização...");
        }

        protected override void ExecuteOperation(Aluno entity)
        {
            Console.WriteLine("Atualizando aluno no banco de dados...");
        }

        protected override void HandleResult()
        {
            Console.WriteLine("Aluno atualizado com sucesso.");
        }

        protected override void Disconnect()
        {
            Console.WriteLine("Desconectando do banco de dados.");
        }
    }

    public class AlunoDeleteOperation : CRUDTemplate<Aluno>
    {
        public override bool Connect()
        {
            Console.WriteLine("Conectado ao banco de dados.");
            return true;
        }

        protected override void PrepareData(Aluno entity)
        {
        }

        protected override void ExecuteOperation(Aluno entity)
        {
            Console.WriteLine("Removendo aluno do banco de dados...");
        }

        protected override void HandleResult()
        {
            Console.WriteLine("Aluno removido com sucesso.");
        }

        protected override void Disconnect()
        {
            Console.WriteLine("Desconectando do banco de dados.");
        }
    }
}

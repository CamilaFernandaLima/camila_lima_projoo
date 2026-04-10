using System;

// 1. Implementação do Singleton
public class ConfiguracaoGlobal
{
    private static ConfiguracaoGlobal instance;

    public string NomeApp = "Sistema de Notificações";
    public string Servidor = "smtp.faculdade.edu.br";
    public int MaxTentativasReenvio = 3;

    //contrutor privado (evitar 'new')
    private ConfiguracaoGlobal() { }

    public static ConfiguracaoGlobal GetInstance()
    {
        if(instance == null)
        {
            instance = new ConfiguracaoGlobal();
        }
        return instance;
    }
}

// 2. Implementação da interface de notificações
public interface INotifica
{
    void Enviar(string mensagem);
}

public class Email : INotifica
{
    public void Enviar(string mensagem)
    {
        var configuracao = ConfiguracaoGlobal.GetInstance();
        Console.WriteLine("Enviando email: " + mensagem);
    }
}

public class SMS : INotifica
{
    public void Enviar(string mensagem)
    {
        Console.WriteLine("Enviando SMS: " + mensagem);
    }
}

public class Push : INotifica
{
    public void Enviar(string mensagem)
    {
        Console.WriteLine("Enviando Push: " + mensagem);
    }
}

//3. API externa inventada (fora do padrão INotifica)
public class APIExternaInventada 
{
    public void EnviarSMS(string texto)
    {
        Console.WriteLine("Enviando SMS via API Externa para" + numero +": " + texto);
    }
}

// adaptador para que ela se encaixe no padrão
public class AdaptadorAPI implements INotifica
{
    private APIExternaInventada apiExterna;

    public AdaptadorAPI(APIExternaInventada api)
    {
        this.apiExterna = api;
    }

    public void Enviar(string mensagem)
    {
        apiExterna.EnviarSMS(mensagem);
    }
}

// 4. Construção do padrão Factory 
public class FactoryNotificacao
{
    public static INotifica Criar(string tipo)
    {
        if (tipo == "email")
        {
            return new Email();
        }
        if (tipo == "sms")
        {
            return new SMS();
        }
        if (tipo == "push")
        {
            return new Push();
        }
        else
        {
            Console.WriteLine("Erro: esse tipo de notificação não existe no sistema.");
            return null;
        }
    }
}

// 4. Programa Main
public class Program
{
    public static void Main()
    {
        Console.WriteLine("Iniciando o sistema...");


        //testes do singleton
        var teste1 = ConfiguracaoGlobal.GetInstance();
        teste1.NomeApp = "App Modificado";

        var teste2 = ConfiguracaoGlobal.GetInstance();
        Console.WriteLine("Nome do App no teste2: " + teste2.NomeApp);

        Console.WriteLine("Enviando Mensagens...");

        INotifica email1 = FactoryNotificacao.Criar("email");
        email1.Enviar("Olá, sua nota está no sistema");

        INotifica sms1 = FactoryNotificacao.Criar("sms");
        sms1.Enviar("Olá, sua nota foi alterada");

    }
}

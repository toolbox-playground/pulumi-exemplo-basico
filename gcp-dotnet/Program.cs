using Pulumi;
using Pulumi.Gcp.CloudRun;
using Pulumi.Gcp.CloudRun.Inputs;
using Pulumi.Gcp.Iam;
using Pulumi.Gcp.Storage;
using System.Collections.Generic;

class MyStack : Stack
{
    public MyStack()
    {
        // Cria um bucket para armazenar a imagem do Docker
        var bucket = new Bucket("bucket");

        // Cria a imagem do Docker e faz o upload para o GCR (Google Container Registry)
        var image = new Image("my-app-image", new ImageArgs
        {
            Build = "./gcp-dotnet", // caminho para o seu app .NET
            Name = "gcr.io/toolbox-sandbox-388523/flask-app:latest"
        });

        // Cria o serviço Cloud Run
        var service = new Service("my-service", new ServiceArgs
        {
            Location = "us-central1", // região do serviço
            Template = new ServiceTemplateArgs
            {
                Spec = new ServiceTemplateSpecArgs
                {
                    Containers = new List<ServiceTemplateSpecContainerArgs>
                    {
                        new ServiceTemplateSpecContainerArgs
                        {
                            Image = image.ImageName
                        }
                    }
                }
            }
        });

        // Define a permissão para permitir invocações não autenticadas
        var invoker = new IamMember("invoker", new IamMemberArgs
        {
            Service = service.Id,
            Role = "roles/run.invoker",
            Member = "allUsers"
        });

        // Exporta a URL do serviço
        this.ServiceUrl = service.Statuses.Apply(statuses => statuses[0].Url);
    }

    [Output]
    public Output<string> ServiceUrl { get; set; }
}

class Program
{
    static Task<int> Main() => Deployment.RunAsync<MyStack>();
}
# pulumi-nodejs-exemplo
Exemplo básico de código usando Pulumi usando NodeJS.

## O que irá encontrar no repositório?
Neste repositório, temos um exemplo básicos de execução do Pulumi com base no cloud Google Cloud Platform. A ideia é trazer de uma forma mais figurativa e prática os passos a passos de cenários de uso do `Pulumi` no dia a dia.

## Como configurar o seu ambiente

### Pré Requisito
Seguir passo a passo da instalação do [Pulumi](https://www.pulumi.com/docs/clouds/gcp/get-started/begin/).
Seguir passo a passo da instalação do [gcloud sdk](https://cloud.google.com/sdk/docs/install).

### Estrutura do repositório
```
|__.github                          # Pasta com os arquivos de CI/CD para o GitHub Actions
|__gcp-node                         # Exemplo prático 
|  |__Pulumi.yaml                   # Estrutura do projeto Pulumi
|  |__index.js                      # Código principal 
|__dotnet                           # Recriar o projeto de node em dotnet            
|__modulos                          # Módulos para execução de infra estrutura
|__CHANGELOG.md                     # Arquivo de controle de changes do repositório
|__CONTRIBUTING.md                  # Arquivo com diretrizes de contribuição
|__package.json                     # Arquivo necessário para geração de versionamento automático
|__README.md                        # Você está lendo esse arquivo
|__.versionrc                       # Arquivo necessário para configuração de versionamento
```

### Como executar o laboratório

- É muito importante conhecer os comandos básicos do Pulumi. 
- Faça download da chave .json para autenticar com o Google Cloud e salve na raiz do projeto com o nome `gcp.json`
~- Criar uma variavel de ambiente `GOOGLE_CREDENTIALS` e adicione o conteúdo do .json da sua service account conforme orientado ~
- Execute a pré configuração do ambiente:\

*Para Windows com powershell*
```
$jsonContent = Get-Content gcp.json | ConvertFrom-Json
$firstObject = $jsonContent[0] | ConvertTo-Json -Compress
$env:GOOGLE_CREDENTIALS = $firstObject
gcloud auth activate-service-account <MINHA-CONTA@MEUPROJETO.iam.gserviceaccount.com> --key-file=MEU-JSON.json
pulumi config set gcp:project <MEU-PROJETO>
pulumi stack init staging; pulumi up; 
```

*Para Linux*
```
export GOOGLE_CREDENTIALS=$(cat gcp.json | jq -c )
export GOOGLE_APPLICATION_CREDENTIALS=gcp.json
gcloud auth activate-service-account <MINHA-CONTA@MEUPROJETO.iam.gserviceaccount.com> --key-file=MEU-JSON.json
pulumi config set gcp:project <MEU-PROJETO>
pulumi stack init staging && pulumi up
```
- Sempre execute os comandos na seguencia: `preview` e `up`. 

Em casos de dúvidas, siga o passo-a-passo [aqui](https://www.pulumi.com/registry/packages/gcp/installation-configuration/).

### Exemplo de Pipeline - ESTÁ SOB CONSTRUÇÃO!


## Contribuindo
Contribuições são bem-vindas! Por favor, leia o arquivo [CONTRIBUTING.md](CONTRIBUTING.md) para mais detalhes.

## Licença
Este projeto está licenciado sob a Licença MIT - veja o arquivo [LICENSE.md](LICENSE.md) para mais detalhes.

### Controle de versão
Para control de versão automático usamos a lib [commit-and-tag-version](https://github.com/absolute-version/commit-and-tag-version)
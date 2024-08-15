## Como executar
pulumi new gcp-python

### Set Up basico
Execute o comando abaixo para instalar as dependências
```
pip install -r requirements.txt
```
### Como usar Stack com config
```
pulumi config set location us-central1
pulumi config set image gcr.io/toolbox-sandbox-388523/flask-app:latest
```
Para editar uma configuração, use: `pulumi config set <key> <value>`
E para remover uma configuração, use: `pulumi config rm <key>`

Você também pode armazenar variáveis sensíveis de forma criptografada: `pulumi config set secretKey secretValue --secret`

### Caso você queira criar uma nova stack
```
 pulumi stack init nova-stack; 
 pulumi review; 
 pulumi up; 
```

### Caso você queira aproveitar uma stack
```
pulumi stack select dev;
pulumi preview;
pulumi up; 
```

### Destrua a infra
```
pulumi destroy; 
```
## Como executar

### Set Up basico
Execute o comando abaixo para instalar as dependências
```
npm install
```

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
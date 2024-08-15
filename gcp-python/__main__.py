import pulumi
from pulumi_gcp import cloudrun, organizations

config = pulumi.Config()

location = config.require("location")
image = config.require("image")

# Criar o serviço do Cloud Run usando as variáveis do stack
default_service = cloudrun.Service('default',
    name='cloudrun-python-srv',
    location=location,
    template={
        'spec': {
            'containers': [{
                'image': image,
                'ports': [{
                    'containerPort': 5000,
                }],
            }],
        },
    })

# Obter a política IAM para noauth
noauth_policy = organizations.get_iam_policy(bindings=[{
    'role': 'roles/run.invoker',
    'members': ['allUsers'],
}])

# Anexar a política IAM ao serviço Cloud Run
noauth_iam_policy = cloudrun.IamPolicy('noauth',
    location=default_service.location,
    project=default_service.project,
    service=default_service.name,
    policy_data=noauth_policy.policy_data
)


# Export the status of the created Cloud Run service
pulumi.export('grun', default_service.statuses)

const pulumi = require("@pulumi/pulumi");
const gcp = require("@pulumi/gcp");

const _default = new gcp.cloudrun.Service("default", {
    name: "cloudrun-srv",
    location: "us-central1",
    template: {
        spec: {
            containers: [{
                image: "gcr.io/toolbox-sandbox-388523/flask-app:latest",
                ports: [{
                    containerPort: 5000, // Porta necessária
                }],
            }],
        },
    },
});

const noauth = gcp.organizations.getIAMPolicy({
    bindings: [{
        role: "roles/run.invoker",
        members: ["allUsers"],
    }],
});

const noauthIamPolicy = new gcp.cloudrun.IamPolicy("noauth", {
    location: _default.location,
    project: _default.project,
    service: _default.name,
    policyData: noauth.then(noauth => noauth.policyData),
});

// Export the status of the created Cloud Run service
exports.grun = _default.status;

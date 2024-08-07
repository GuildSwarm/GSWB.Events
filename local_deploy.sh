#!/bin/bash
set -eux

Environment=development

# tarball csproj files, sln files, and NuGet.config
find . \( -name "*.csproj" -o -name "*.sln" -o -name "NuGet.docker.config" \) -print0 \
    | tar -cvf projectfiles.tar --null -T -

docker build . --build-arg ENVIRONMENT=$Environment --no-cache -t registry.guildswarm.org/$Environment/events:latest
if [[ $0 == 1 || 0 ]]
then
    rm projectfiles.tar
fi
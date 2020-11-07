#!/bin/bash

# https://vaneyckt.io/posts/safer_bash_scripts_with_set_euxo_pipefail/
set -Eeuxo pipefail

echo "Downloading dotnet 5.0"
curl -o /tmp/dotnet5.tar.gz https://download.visualstudio.microsoft.com/download/pr/69cb8922-7bb0-4d3a-aa92-8cb885fdd0a6/2fd4da9e026f661caf8db9c1602e7b2f/dotnet-sdk-5.0.100-rc.2.20479.15-linux-x64.tar.gz

echo "Installing  dotnet 5.0"
tar xvf /tmp/dotnet5.tar.gz  -C /home/codespace/.dotnet/

echo "post create succeeded"

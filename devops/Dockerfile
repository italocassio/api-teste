FROM mcr.microsoft.com/dotnet/sdk:6.0
LABEL version="1.0"

WORKDIR /app
COPY . .
RUN ls .
RUN dotnet publish ./api-auction.csproj -o ./dist

FROM mcr.microsoft.com/dotnet/sdk:6.0

RUN apt-get update && apt-get upgrade -y && apt-get install -y \
    curl \
    bash \
    bc \
    unzip \
    gcc && rm -rf /var/lib/apt/lists/*

WORKDIR /app

COPY --from=0 /app/dist/ .
COPY ./devops/run.sh .

ENV DOTNET_VERSION 6.0

ENTRYPOINT ["bash", "run.sh" ]


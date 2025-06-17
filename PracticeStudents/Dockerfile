# Этап сборки
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /app

# Копируем файл проекта и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем остальные файлы и собираем проект в релизной конфигурации
COPY . ./
RUN dotnet publish -c Release -o out

# Этап выполнения
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS runtime
WORKDIR /app

# Копируем собранные файлы из предыдущего этапа
COPY --from=build /app/out ./

# Открываем порт 80
EXPOSE 80

# Запускаем приложение (замените YourAppName.dll на имя вашего dll)
ENTRYPOINT ["dotnet", "PracticeStudents.dll"]

export function getAppConfig(): Promise<AppConfig> {
    return fetch("config/appsettings.json").then(response => response.json() as unknown as AppConfig);
}

export interface AppConfig
{
    apiBaseUrl: string;
}
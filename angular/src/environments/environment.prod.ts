import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'BackTester',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44384/',
    redirectUri: baseUrl,
    clientId: 'BackTester_App',
    responseType: 'code',
    scope: 'offline_access BackTester',
    requireHttps: true
  },
  apis: {
    default: {
      url: 'https://localhost:44384',
      rootNamespace: 'NaniTrader.BackTester',
    },
  },
} as Environment;

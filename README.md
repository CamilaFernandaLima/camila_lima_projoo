# Sistema de envio de Notificações com Factory e Singleton

Uma empresa deseja desenvolver um sistema capaz de enviar notificações por diferentes canais, como e-mail, SMS e push notification. O sistema deve ser flexível para permitir a inclusão de novos tipos de notificação no futuro, sem alterar excessivamente o código existente. Além disso, a aplicação deve possuir um único componente central responsável por armazenar configurações globais do sistema, como nome da aplicação, servidor de envio e quantidade máxima de tentativas de reenvio.

*OBJETIVO* 

Implementar um pequeno sistema orientado a objetos que:
- utilize o padrão Factory para criar objetos de notificação;
- utilize o padrão Singleton para garantir uma única instância de configuração global;

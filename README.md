[![Static Badge](https://img.shields.io/badge/100%20Commits-green?style=for-the-badge&label=The%20project%20participates%20in&link=right%2Fhttps%3A%2F%2F100commitow.pl)](https://100commitow.pl)
[![Static Badge](https://img.shields.io/badge/MIT-orange?style=for-the-badge&label=License)](https://github.com/KarolMaliglowka/SurveysPortal/blob/master/License)
---
Survey's Portal
===

A survey is one of the most popular sources of data collection. A set of survey questions is sent to users who can answer the questions. Users receive online surveys through various media, such as e-mail or by sending a link.
What is the purpose of conducting online surveys? Online surveys are conducted to obtain feedback, both positive and negative, from current or potential customers, employees and users.
It can be carried out, for example, on: introducing new products or services, changes in marketing strategies, improvements to current functions, etc.

- [About application](#about-application)
- [Used technologies](#Used-technologies)
- [Solution structure](#Solution-structure)
    - [Frontend](#Frontend)
    - [Backend](#Backend)
        - [Bootstrapper](#Bootstrapper)
        - [Modules](#Modules)
        - [Shared](#Shared)
    - [Doc](#Docs)
- [Application usage](#Application-usage)
  - [Dependence](#Dependence)
  - [Clone from GitHub](#Clone-from-GitHub)
- [License](#License)

## About application
The application allows you to send the created survey to users registered in the system. You can use [Google](http://google.pl), [LinkedIn](https://linkedin.com) or [Facebook](https://facebook.com) authentication to log in. You can create two types of surveys (eventually more): simple (yes, no) and those requiring a longer, descriptive answer. The person creating and sending the surveys may receive responses after some time.

## Used technologies

in backend:

| Technology                                      | Version |
|-------------------------------------------------|---------|
| [`DOTNET`](https://dotnet.microsoft.com/en-us/) | 8.0.100 |
| [`Postgresql`](https://www.postgresql.org.pl/)  | x.x.x   |
| [`Docker`](https://www.docker.com/)             | x.x.x   |
| [`RabbitMQ`](https://www.rabbitmq.com/)         | x.x.x   |

in frontend web:

| Technology                                           | Version |
|------------------------------------------------------|---------|
| [`Angular`](https://angular.io/)                     | 17.3.0  |
| [`Typescript`](https://www.typescriptlang.org/)      | 5.4.2   |
| [`PrimeNG`](https://primeng.org/)                    | 17.11.0 |
| [`Sakai-NG`](https://github.com/primefaces/sakai-ng) | 17.0.0  |

in fronted mobile(maybe):

| Technology                                             | Version |
|--------------------------------------------------------|---------|
| [`MAUI`](https://dotnet.microsoft.com/en-us/apps/maui) | x.x.x   |

## Solution structure

### Frontend
Web application responsible for interacting with the user and presenting feedback data.

### Backend
#### Bootstrapper
Application responsible for initializing and starting all the modules - loading configurations, running DB migrations, exposing public APIs etc.

#### Modules
Autonomous modules with the different set of responsibilities, highly decoupled from each other - there's no reference between the modules at all (such as shared projects for the common data contracts), and the synchronous communication & asynchronous integration (via events) is based on local contracts approach.

- Surveys - managing surveys
  - Simple surveys
  - Standard surveys
- Notifications - notification management (e.g. feedback from API).
- Users - managing the users/identity (register, login, permissions etc.).

#### Shared
The set of shared components for the common abstractions & cross-cutting concerns. In order to achieve even better
decoupling, it's split into the separate *Abstractions* and *Infrastructure*, where the former does contain public abstractions and the latter their implementation.

### Docs
A place to store documentation.

[Database manual migrations](src/Docs/Database_Migrations.md)

## Application usage

### Dependence

### Clone from GitHub

## License
This project is licensed under the [MIT License](License). Feel free to use, modify, and distribute as per the terms of the license.

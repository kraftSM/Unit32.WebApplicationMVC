# Unit32.WebApplicationMVC
домашняя ра,ота по Unit32 - MVC приложение, для упрощения использовано ASP5
- в MidlleWare помещено логирование приложения, в частности запросов по страницам сайта
  - - логирование ведется в консоль, БД а так же и в техтовой файл 
   -  - Запись Лога запросов в техтовой файл реализована, но отключена
   -  - Имя файла для логирования может быть постоянным = RequestLog.txt или иметь изменяемый 'хвост' - YYYYMMDD_HHMM
   -  при логировании в БД используется общий с контекст ДБ с сообщениями пользователя, но отдельный репозиторий. Log доступен через home/logrq/index ( формируется via LogRqController )
-Механизм отзывов через Ajax  (partial)Forms реализован в формах регистрации и отзывов
  - под это сделаны ссылки на Навигационной панели Register;  Contact Us
  - CSS- форматирование по минимому (списано из уроков), далее не делалось
# Unit32.WebApplicationMVC NOTICE for MEE!!
не для проверящих (сорри что наприсано здесь, но это важно...:( )
# # CODE 1-ST (ЧАСТО!!!) порождает "странные" ошибки, которые "лечаться" удалением SQL-баз или специальными действиями по синхронизации изменений в проекте, via обновлений соответствий CODE<->SQL

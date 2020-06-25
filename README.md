<p align="center"><img src="https://res.cloudinary.com/dtfbvvkyp/image/upload/v1566331377/laravel-logolockup-cmyk-red.svg" width="400"></p>

## About Laravel

Laravel is a web application framework with expressive, elegant syntax. We believe development must be an enjoyable and creative experience to be truly fulfilling.
Laravel is accessible, powerful, and provides tools required for large, robust applications.

## Steps to run the transfer application

1. Install XAMPP
    https://www.apachefriends.org/download.html
    https://www.youtube.com/watch?v=-f8N4FEQWyY
    1.1 press 'start' apache and mySQL 
    
2. Create a database
    2.1 Write in browser localhost/phpmyadmin
    2.2 Create database with name transferapp.sql
    2.3 Import transferapp.sql
    
3. Install composer 
    https://getcomposer.org/
    
4. Download the laravel zip project from github

5. Drag unzipped folder to xampp/htdocs folder

6. Open terminal (CMD) and write these commands:
    5.1 cd <i>yourUnzippedFolderLocation<i>
    5.2 composer install
    
7. There are two options to run the application
    A Using a terminal
        A.1 Write command: php artisan serve
        A.2 Wopy the shown link and paste it in browser. It should loo like this -> http://127.0.0.1:8000
    B Using a browser
        B.1 Write localhost/<i>FolderNameWhereYourProjectIs<i>
        B.2 Click on the folder and find the folder inside with title <i>public<i> and click it 
    
8. Try it :)

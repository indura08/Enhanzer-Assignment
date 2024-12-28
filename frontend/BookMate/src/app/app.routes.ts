import { Routes } from '@angular/router';
import { HomeComponent } from './Pages/home/home.component';
import { BooksComponent } from './Pages/books/books.component';

export const routes: Routes = [
    {
        path: "",
        component: HomeComponent
    },

    {
        path: "books",
        component: BooksComponent
    }
];

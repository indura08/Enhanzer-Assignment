import { Component, OnInit } from '@angular/core';
import { HeaderComponent } from '../../components/header/header.component';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { Book } from '../../data-models/Book';
import { BookService } from '../../../services/book.service';
import { HttpErrorResponse } from '@angular/common/http';
import { error } from 'console';
import { response } from 'express';
@Component({
  selector: 'books',
  standalone: true,
  imports: [HeaderComponent, CommonModule,FormsModule],
  templateUrl: './books.component.html',
  styleUrl: './books.component.css'
})
export class BooksComponent implements OnInit {

  public books:Book[] = [];

  public currentBook:Book ={
    id:0,
    title:"",
    isbn:"",
    publicationDate:"",
    author:""
  }

  constructor(private bookService:BookService){}

  ngOnInit(): void {
      this.getBooks();
  }

  public getBooks():void{
    this.bookService.getBooks().subscribe(
      (response:Book[]) => {
        this.books = response;
        //alert("Books were fetched")
        console.log(this.books[1])
      },
      (error: HttpErrorResponse) => {
        console.log(error) //this is for debugging purposes, should be removed after debuging and making sure project is 100% error free
        alert("Error occured please try again later")
      }
    )
  }

  public setCurrentBook(book:Book){
    this.currentBook = book;
  }

  public deleteBook(id:number){
    this.bookService.deleteBookById(id).subscribe(
      (response:string) => {
        console.log(response)
        alert("Success")
      },

      (error:HttpErrorResponse) => {
        console.log(error)
        alert("Error occured");
      }
    )

  }

  public createBook(bookForm:NgForm){
    this.bookService.createNewBook(bookForm.value).subscribe(
      (response:string) => {
        console.log(response)
        alert("Book created")
      },

      (error:HttpErrorResponse) => {
        alert("Error occured when createing a book");
        console.log(error)
      }
    )
  }

  public updateBook( id: number, updateBook:NgForm){
    this.bookService.updateBookById(id, updateBook.value).subscribe(
      (response:string) => {
        alert("Updated")
      },

      (error:HttpErrorResponse) => {
        alert("Error occured while updating book")
        console.log(error);
        console.log(updateBook.value);
      }
    )
  }

}

import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Book {
  rowNumber: number
  dataRetrievalType: string;
  isbn: string;
  title: string;
  subtitle: string;
  authorNames: string;
  numberOfPages: string;
  publishDate: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public books: Book[] = [];
  public isValidFile: boolean = false;
  private file: File = {} as File;

  constructor(private http: HttpClient) {}

  ngOnInit() {
  }
  
  validateFile(eventFile: any) {
    var files = eventFile.target.files;
    if (files.length == 1 && files[0].name.endsWith(".txt")) {
      this.file = files[0];
      this.isValidFile = true;
    }
    else {
      this.isValidFile = false;
      this.books = [];
    }
  }

  getBooksData() {
    this.books = [];
    let fileReader = new FileReader();
    let stringValue: string;
    fileReader.onload = (e) => {
      stringValue = (fileReader.result as string).replace(/(?:\r\n|\r|\n)/g, ',');
      this.getBooksDataApi(stringValue);
    }
    fileReader.readAsText(this.file);
  }

  getBooksDataApi(stringValue: string) {
    const body = stringValue.split(',');
    this.http.post<Book[]>('/book', body).subscribe(
      (result) => {
        this.books = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'Books';
}

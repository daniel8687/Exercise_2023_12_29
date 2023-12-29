import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';

describe('AppComponent', () => {
  let component: AppComponent;
  let fixture: ComponentFixture<AppComponent>;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AppComponent],
      imports: [HttpClientTestingModule]
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should create the app', () => {
    expect(component).toBeTruthy();
  });

  it('should retrieve books from the server', () => {
    const mockBooks = [
      { dataRetrievalType: 'dataRetrievalType1', isbn: '1', title: 'title1', subtitle: 'subtitle1', authorNames: 'authorNames1', numberOfPages: '1', publishDate: 'publishDate1' },
      { dataRetrievalType: 'dataRetrievalType2', isbn: '2', title: 'title2', subtitle: 'subtitle2', authorNames: 'authorNames2', numberOfPages: '2', publishDate: 'publishDate2' }
    ];

    component.ngOnInit();

    const req = httpMock.expectOne('/book');
    expect(req.request.method).toEqual('POST');
    req.flush(mockBooks);

    expect(component.books).toEqual(mockBooks);
  });
});

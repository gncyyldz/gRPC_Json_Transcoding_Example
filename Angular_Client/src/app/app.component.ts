import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  template: `
    {{texts}}
    <br>
    <input type="text" placeholder="Name" [(ngModel)]="name" /> <br>
    <input type="text" placeholder="Surname" [(ngModel)]="surname"  /> <br>
    <button (click)="createPerson()">Create</button>
  `
})
export class AppComponent implements OnInit {
  constructor(private httpClient: HttpClient) { }

  texts: string;
  ngOnInit() {
    const text: string = "Mesajlar alınmaya başlanmıştır.";
    const observable: Observable<any> = this.httpClient.get(`https://localhost:7018/message/${text}`, { responseType: 'text' });
    observable.subscribe(data => this.texts = data);
  }

  name: string;
  surname: string;
  createPerson() {
    const observable: Observable<any> = this.httpClient.post("https://localhost:7018/persons", { name: this.name, surname: this.surname });
    observable.subscribe(data => console.log(data));
  }
}

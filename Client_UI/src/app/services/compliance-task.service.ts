import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ItemService } from '../models/task.model';
import { ItemServiceRequest } from '../models/task.request';

@Injectable({
  providedIn: 'root',
})
export class ItemServiceService {
  private apiUrl = 'http://localhost:5000/api/ItemService';

  constructor(private http: HttpClient) {}

  getTasks(): Observable<ItemService[]> {
    return this.http.get<ItemService[]>(`${this.apiUrl}/tasks`);
  }

  addTask(task: ItemServiceRequest): Observable<ItemService> {
    return this.http.post<ItemService>(`${this.apiUrl}/task`, task);
  }

  //TODO: Implement streaming to support displaying the results as each ItemService's data processing is completed.
  calculateFactorial(): Observable<ItemService[]> {
    return this.http.get<ItemService[]>(`${this.apiUrl}/tasks/factorial`);
  }
}

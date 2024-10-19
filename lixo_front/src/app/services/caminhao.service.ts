import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Caminhao } from '../models/caminhao.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CaminhaoService {
  private apiUrl = 'https://localhost:7012/api/Caminhao';
  constructor(private http: HttpClient) { }
  getCaminhoes(): Observable<Caminhao[]> {
    return this.http.get<Caminhao[]>(this.apiUrl + '/ListarCaminhoes');
  }
}

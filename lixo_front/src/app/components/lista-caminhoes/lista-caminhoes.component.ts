import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CaminhaoService } from '../../services/caminhao.service';
import { Caminhao } from '../../models/caminhao.model';

@Component({
  selector: 'app-lista-caminhoes',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './lista-caminhoes.component.html',
  styleUrl: './lista-caminhoes.component.css'
})
export class ListaCaminhoesComponent {
  caminhoes: Caminhao[] = [];

  constructor (private caminhaoService: CaminhaoService) {}

  ngOnInit(): void {
    this.caminhaoService.getCaminhoes().subscribe(
      (data) => {
        this.caminhoes = data;
    });
  }
}

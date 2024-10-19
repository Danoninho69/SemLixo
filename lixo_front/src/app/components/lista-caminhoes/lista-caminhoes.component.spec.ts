import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaCaminhoesComponent } from './lista-caminhoes.component';

describe('ListaCaminhoesComponent', () => {
  let component: ListaCaminhoesComponent;
  let fixture: ComponentFixture<ListaCaminhoesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ListaCaminhoesComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ListaCaminhoesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

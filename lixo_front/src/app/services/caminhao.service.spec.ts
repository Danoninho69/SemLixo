import { TestBed } from '@angular/core/testing';

import { CaminhaoService } from './caminhao.service';

describe('CaminhaoService', () => {
  let service: CaminhaoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CaminhaoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

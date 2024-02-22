import { TestBed } from '@angular/core/testing';

import { CEPService } from './cep.service';

describe('CEPService', () => {
  let service: CEPService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CEPService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

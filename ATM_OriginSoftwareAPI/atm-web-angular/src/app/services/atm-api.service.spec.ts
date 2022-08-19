import { TestBed } from '@angular/core/testing';

import { AtmApiService } from './atm-api.service';

describe('AtmApiService', () => {
  let service: AtmApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AtmApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

import { TestBed } from '@angular/core/testing';

import { PokePictureService } from './poke-picture.service';

describe('PokePictureService', () => {
  let service: PokePictureService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PokePictureService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});

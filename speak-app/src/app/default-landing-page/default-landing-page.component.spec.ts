import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DefaultLandingPageComponent } from './default-landing-page.component';

describe('DefaultLandingPageComponent', () => {
  let component: DefaultLandingPageComponent;
  let fixture: ComponentFixture<DefaultLandingPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DefaultLandingPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DefaultLandingPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should be created', () => {
    expect(component).toBeTruthy();
  });
});

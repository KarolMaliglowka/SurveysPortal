import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StandardQuestionListComponent } from './standard-question-list.component';

describe('StandardQuestionListComponent', () => {
  let component: StandardQuestionListComponent;
  let fixture: ComponentFixture<StandardQuestionListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [StandardQuestionListComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(StandardQuestionListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { Component, Input, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'example-mapping',
  templateUrl: './example-mapping.component.html',
  styleUrls: ['./example-mapping.component.css']
})
export class ExampleMappingComponent {
  inputStory: MappingStory;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    var i = "S1";
    http.get<MappingStory>(baseUrl + 'api/MappingStory/' + i).subscribe(result => {
      this.inputStory = result;
    }, error => console.error(error));

    //this.title = 'Hello, World!';
    //this.inputStory = this.createDummyStory();
  }

  createDummyStory() {
    var s: MappingStory;
    s = {
      id: "STEST",
      title: "Test story",
      description: "Test story description",
      mappingQuestions: [
        { description: "Question 1" },
        { description: "Question 2" }
      ],
      mappingRuleSections: [
        {
          description: "",
          mappingRules: [
            {
              description: "Rule 1",
              mappingExamples: [
                { description: "Example 1 A" },
                { description: "Example 1 B" }
              ]
            },
            {
              description: "Rule 2",
              mappingExamples: [
                { description: "Example 2 A" },
                { description: "Example 2 B" }
              ]
            }
          ]
        }
      ]
    };
    return s;
  }
}

@Component({
  selector: 'mapping-story',
  templateUrl: './mapping-story.component.html'
})
export class MappingStoryComponent {
  @Input() story: MappingStory;

  constructor() {
  }

  addQuestion() {
    this.story.mappingQuestions.push({
      description: ""
    });
  }

  addRule() {
    this.story.mappingRuleSections[0].mappingRules.push({
      description: "",
      mappingExamples: []
    });
  }
}

@Component({
  selector: 'mapping-rule',
  templateUrl: './mapping-rule.component.html'
})
export class MappingRuleComponent {
  @Input() rule: MappingRule;

  constructor() {
  }

  addExample() {
    this.rule.mappingExamples.push({
      description: ""
    });
  }
}

@Component({
  selector: 'mapping-example',
  templateUrl: './mapping-example.component.html'
})
export class MappingExampleComponent {
  @Input() example: MappingExample;

  constructor() {
  }
}

@Component({
  selector: 'mapping-question',
  templateUrl: './mapping-question.component.html'
})
export class MappingQuestionComponent {
  @Input() question: MappingQuestion;

  constructor() {
  }
}


export class MappingStory {
  public id: string;
  public title: string;
  public description: string;
  public mappingRuleSections: MappingRuleSection[];
  public mappingQuestions: MappingQuestion[];
}

export class MappingRuleSection {
  public description: string;
  public mappingRules: MappingRule[];
}

export class MappingRule {
  public description: string;
  public mappingExamples: MappingExample[];
}

export class MappingExample {
  public description: string;
}

export class MappingQuestion {
  public description: string;
}

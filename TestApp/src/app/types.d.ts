export interface TestConfig {
  title: string;
  cases: { url: string; result: string }[];
}

export interface SectionConfig {
  category: string;
  tests: TestConfig[];
}

export interface Response {
  result: any;
  time: number;
  ticks: number;
}

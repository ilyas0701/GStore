import { Logger } from "tslog"

export const logger = new Logger({
  type: "pretty",
  prettyLogTemplate:
    "{{yyyy}}.{{mm}}.{{dd}} {{hh}}:{{MM}}:{{ss}}:{{ms}}\t{{logLevelName}}\t[{{filePathWithLine}}{{name}}]\t",
  stylePrettyLogs: true,
  prettyLogTimeZone: "UTC",
  prettyLogStyles: {
    logLevelName: {
      "*": ["bold", "black", "bgWhiteBright", "dim"],
      "SILLY": ["bold", "white"],
      "TRACE": ["bold", "whiteBright"],
      "DEBUG": ["bold", "green"],
      "INFO": ["bold", "blue"],
      "WARN": ["bold", "yellow"],
      "ERROR": ["bold", "red"],
      "FATAL": ["bold", "redBright"],
    },
    dateIsoStr: "white",
    filePathWithLine: "white",
    name: ["white", "bold"],
    nameWithDelimiterPrefix: ["white", "bold"],
    nameWithDelimiterSuffix: ["white", "bold"],
    errorName: ["bold", "bgRedBright", "whiteBright"],
    fileName: ["yellow"],
  },
})

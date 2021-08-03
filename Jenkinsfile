pipeline {
    agent any
    stages {
        stage('build') {
            steps {
                echo 'susu build application'
                sh "pwd"
            }
        }
        environment {
            QA_Workspace = './QA'
        }
        stage('git clone') {
            steps {
                script {
                    sh "git clone git@github.com:tell6530/DesignPattern.git"
                }
            }
        }
    }
}